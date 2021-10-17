#!/bin/bash

print_help(){
  echo "
    $(tput bold)* HELP *$(tput sgr0)

  $(tput bold)RUN$(tput sgr0)
    ./script.sh [OPTIONS]

  $(tput bold)DESCRIPTION$(tput sgr0)

  Merge external project to current via subtree merge technology

  $(tput bold)OPTIONS$(tput sgr0)
          remote options
      -n --remote_name    set remote name (mast be specified !!! )
      -b --remote_branch  branch to merge (default: master)
      -u --url            remote repo url (mast be specified !!! )
      ------------------------------------------------------------
          merge commit options
      -l --local_branch   merge remote repo in a specified local branch (default: your current)
      -d --dir            dir to place subproject (default: remote_name)
      -m --msg            commit message  (default: 'Merge 'remote_name' project')
      ------------------------------------------------------------
          flags (without values)
      -h --help           print this info
      -r --remove_remote  run 'git remote remove remote_name after merge'
      "
}


getopt_flags="help,remove_remote"
getopt_options="remote_name:,remote_branch:,url:,local_branch:,dir:,msg:"
options=$(getopt -l "$getopt_flags,$getopt_options" -o "hrn:b:u:l:d:m:" -- "$@")
eval set -- "$options"


remote_branch="master"
remove_remote=0
local_branch="$(git rev-parse --abbrev-ref HEAD)" # get current branch
cd_dir=0

# Flags processing
while true; do
  case $1 in
    -h|--help) print_help && exit               ;;
    -r|--remove_remote) remove_remote=1         ;;

    -n|--remote_name)   shift; remote_name=$1   ;;
    -b|--remote_branch) shift; remote_branch=$1 ;;
    -u|--url)           shift; url=$1           ;;

    -l|--local_branch)  shift; local_branch=$1  ;;
    -d|--dir)           shift; dir=$1; cd_dir=1 ;;
    -m|--msg)           shift; commit_msg=$1    ;;
    --) shift; break ;;
  esac
  shift
done

if [[ -z "$commit_msg" ]]; then
  commit_msg="Merge '$remote_name' project"
fi

if [[ $cd_dir -eq 0 ]] || ! [[ -d $dir ]]; then
    mkdir "$remote_name" &> /dev/null
    dir="$remote_name"
fi
git checkout "$local_branch" &> /dev/null || git checkout -b "$local_branch"

echo "
  remote name     | $remote_name
  remote branch   | $remote_branch
  url             | $url

  local_branch    | $local_branch
  commit msg      | $commit_msg
  dir             | $dir
  "

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


git remote add -f "$remote_name" "$url"
git merge -s ours --allow-unrelated-histories --no-commit "$remote_name/$remote_branch"
git read-tree --prefix="$dir/" -u "$remote_name/$remote_branch"
git commit -m "$commit_msg"

if [[ $remove_remote -eq 1 ]]; then
  git remote remove "$remote_name"
fi
