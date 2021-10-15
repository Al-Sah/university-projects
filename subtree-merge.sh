#!/bin/bash

print_help(){
  echo "
    $(tput bold)* HELP *$(tput sgr0)

  $(tput bold)RUN$(tput sgr0)
    ./script.sh [OPTIONS]

  $(tput bold)DESCRIPTION$(tput sgr0)

  Merge external project to current via subtree merge technology

  $(tput bold)OPTIONS$(tput sgr0)

      -h --help:        print this info
      -r --remote:      set remote name (mast be specified !!! )
      -u --url:         remote repo url (mast be specified !!! )
      -b --branch:      branch to merge (default: master)
      -m --msg:         commit message  (default: 'Merge '\$remote_name' project')
      -B --new_branch:  create and merge remote repo in a new local branch
      "
}

# Extracting flags from positional parameters
options=$(getopt -l "help,remote:,url:,branch:,msg:,new_branch:" -o "hm:r:u:b:m:B:" -- "$@")
eval set -- "$options"; # Sorting flags and positional parameters with "--" delimiter

branch="master"

# Flags processing
while true; do
  case $1 in
  -r|--remote)  shift; remote_name=$1 ;;
  -u|--url)     shift; url=$1         ;;
  -b|--branch)  shift; branch=$1      ;;
  -m|--msg)     shift; commit_msg=$1  ;;
  -h|--help)    print_help && exit    ;;
  -B|--new_branch) shift; new_local_branch=$1;;
  --) shift; break ;;
  esac
  shift
done

if [[ -z "$commit_msg" ]]; then
  commit_msg="Merge '$remote_name' project"
fi


echo "
  remote name     | $remote_name
  url             | $url
  branch          | $branch
  commit msg      | $commit_msg
  new local branch| $new_local_branch"

check() {
  local res
  # shellcheck disable=SC2162
  read -p "Continue? (Y/n): " res
  if [[ -z $res ]] || [[ "$res" == "Y" ]]; then
    return 1
  else
    return 0 # have to stop
  fi
}

if [[ -z $remote_name ]] || [[ -z $url ]]; then
  echo " Empty variable !!! You have to run script with all necessary parameters" && exit 1
else
  # call function check() and handle return code (0 - stop)
  if check; then
    echo " Stop ! " && exit
  fi
fi


if [[ -n $new_local_branch ]]; then
  git checkout -b "$new_local_branch"
fi

git remote add -f "$remote_name" "$url"
git merge -s ours --allow-unrelated-histories --no-commit "$remote_name/$branch"
mkdir "$remote_name"
git read-tree --prefix="$remote_name/" -u "$remote_name/$branch"
git commit -m "$commit_msg"
git remote remove "$remote_name"
