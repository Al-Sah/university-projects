#!/bin/bash

print_help(){
  echo "
    $(tput bold)* HELP *$(tput sgr0)

  $(tput bold)RUN$(tput sgr0)
    sudo ./setup-nginx-config.sh [OPTIONS]

  $(tput bold)DESCRIPTION$(tput sgr0)

  Generates config file using template.

  $(tput bold)OPTIONS$(tput sgr0)

          options (you can set values)
      -n --name       set config filename (default: nginx.conf)
      -s --server     set server name (default: alxlab)
      ------------------------------------------------------------
          flags (without values)
      -h --help       print this info
      -i --include    include generated file in '/etc/nginx/sites-enabled/'
      -d --disable    disable nginx reload
      "
}

# output messages
start="$(tput bold) $(tput setaf 2)"
end="$(tput sgr0)"

getopt_flags="help,include,disable"
getopt_options="name:,server:"
options=$(getopt -l "$getopt_flags,$getopt_options" -o "hidn:s:" -- "$@")
eval set -- "$options"


filename="nginx.conf"
include=0
disable=0
servername="alxlab"

while true; do
  case $1 in
    -h|--help)    print_help && exit  ;;
    -i|--include) include=1           ;;
    -d|--disable) disable=1           ;;

    -n|--name)    shift; filename=$1  ;;
    -s|--server)  shift; servername=$1  ;;
    --)           shift; break;;
  esac
  shift
done



if ! [[ -f "nginx.conf.template" ]]; then
   echo "$(tput setaf 1) nginx.conf.template not found.$end"
   exit
fi

cp "nginx.conf.template" "$filename"
echo "$start Created new file ($filename) $end"


fastcgi=$"include fastcgi_params;\n"
fastcgi=$"$fastcgi\t\tfastcgi_param SCRIPT_FILENAME \$document_root\$fastcgi_script_name;\n"
fastcgi=$"$fastcgi\t\tfastcgi_param SCRIPT_NAME \$fastcgi_script_name;\n"
fastcgi=$"$fastcgi\t\tfastcgi_pass unix:/var/run/php/php-fpm.sock;"

# do not forget about hosts ... (/etc/hosts)
sed -i "s#{S_NAME}#$servername#" "$filename"
sed -i "s#{PROJ_ROOT}#$(pwd)#" "$filename"
sed -i "s#{FASTCGI}#$fastcgi#" "$filename"



if [[ $include == 1 ]]; then
  echo "$start Including config file ... $end"
  sudo ln -s "$(pwd)/$filename" "/etc/nginx/sites-enabled/alx-lab-itech"
fi


if [[ $disable != 1 ]]; then
  echo "$start Reloading nginx ... $end"
  sudo systemctl reload nginx
fi
