#!/usr/bin/env bash

find . -iname run.sh | while read l ;  do
 echo "------------------------------------------------"
 dir_name="`dirname $l`"
 cd $dir_name ;  
 echo $dir_name
 . ./run.sh  ; 
 cd .. ;  
done 