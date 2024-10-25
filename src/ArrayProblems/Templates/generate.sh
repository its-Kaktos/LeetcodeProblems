#!/bin/bash

name_space="ArrayProblems"

echo "Enter question link"
IFS= read -r ql

cat << EOF
For Easy questions enter 1"
For Medium questions enter 2"
For Hard questions enter 3"
EOF

echo "Enter your question difficulty: "
IFS= read -r qs

if [ -z "$qs" ] || ! [[ "$qs" =~ ^(1|2|3)$  ]]; then
  echo "Question difficulty can only be one of (1, 2, 3)"
  exit 1
fi

echo "Enter your question name with its number: "
read -r qn

if [ -z "$qn" ]; then
	echo "Question name can not be empty"
	exit 1
fi

difficulty=""
case $qs in
 1)
   difficulty="Easy"
   ;;
 2)
   difficulty="Medium"
   ;;
 3)
   difficulty="Hard"
   ;;
 *)
   echo "should not reach here"
   exit 1
   ;;
esac

qn=$(echo "$qn" | sed "s/ /_/g" | sed "s/\.//g")
name_space="${name_space}.${difficulty}._${qn}"

echo "Question difficulty is $qs and question name is $qn and generated namespace would be $name_space"
echo "And question link would be $ql"
echo "Is the provided information valid? (y/n)"
read -r iv

if [ -z "$iv" ] || ! [[ "$iv" =~ ^(y|Y)$  ]]; then
	echo "Exiting based on your input"
	exit 1
fi

case $qs in
 1)
   cp ./Problem.cs ../Easy/
   cp ./Tests.cs ../Easy/
   cd ../Easy || exit 1
   ;;
 2)
   cp ./Problem.cs ../Medium/
   cp ./Tests.cs ../Medium/
   cd ../Medium || exit 1
   ;;
 3)
   cp ./Problem.cs ../Hard/
   cp ./Tests.cs ../Hard/
   cd ../Hard || exit 1
   ;;
 *)
   echo "should not reach here"
   exit 1
   ;;
esac

# TODO change LINK, NAME SPACE
# TODO have project name as a input too so this script can be used as a general
# TODO script for every project instead of having a copy of this script in every project.

echo "Generating problem complete!"