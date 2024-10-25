#!/bin/bash

# Define color codes
RED='\033[0;31m'
GREEN='\033[0;32m'
NC='\033[0m' # No Color

# Define project options
declare -A projects=( ["1"]="ArrayProblems" ["2"]="DynamicProgramming" ["3"]="StringsProblems" )
declare -A difficulties=( ["1"]="Easy" ["2"]="Medium" ["3"]="Hard" )

# Function to print messages
print_message() {
  echo -e "${GREEN}$1${NC}"
}

# Function to handle errors
handle_error() {
  echo -e "${RED}$1${NC}"
  exit 1
}

# Function to validate input
validate_input() {
  local input=$1
  local valid_options=("$@")
  for option in "${valid_options[@]:1}"; do
    if [[ "$input" == "$option" ]]; then
      return 0
    fi
  done
  return 1
}

# Prompt for project selection
print_message "Where do you want to add your problem to?"
for key in "${!projects[@]}"; do
  print_message "For ${projects[$key]} enter $key"
done

IFS= read -r qp
validate_input "$qp" "${!projects[@]}" || handle_error "Selected project can only be one of (1, 2, 3)"

selected_project="${projects[$qp]}"

# Prompt for question link
print_message "Enter question link:"
IFS= read -r ql

# Prompt for difficulty selection
print_message "For Easy questions enter 1"
print_message "For Medium questions enter 2"
print_message "For Hard questions enter 3"
print_message "Enter your question difficulty:"

IFS= read -r qs
validate_input "$qs" "${!difficulties[@]}" || handle_error "Question difficulty can only be one of (1, 2, 3)"

difficulty="${difficulties[$qs]}"

# Prompt for question name
print_message "Enter your question name with its number:"
IFS= read -r qn
[[ -z "$qn" ]] && handle_error "Question name cannot be empty"

# Format question name
qn=$(echo "$qn" | sed "s/ /_/g" | sed "s/\.//g")
name_space="${selected_project}.${difficulty}._${qn}"

print_message "Selected project is $selected_project and question difficulty is $difficulty"
print_message "Question name is $qn and generated namespace would be $name_space"
print_message "And question link would be $ql"
print_message "Is the provided information valid? (y/n)"

IFS= read -r iv
[[ -z "$iv" || ! "$iv" =~ ^(y|Y)$ ]] && handle_error "Exiting based on your input"

directory_path="../src/$selected_project/$difficulty/$qn"

mkdir -p "$directory_path" || handle_error "Failed to create directory"

cp ./Problem.cs "$directory_path" || handle_error "Failed to copy Problem.cs"
cp ./Tests.cs "$directory_path" || handle_error "Failed to copy Tests.cs"

cd "${directory_path}" || handle_error "Failed to change directory"

# Update files
sed -i "s/NAMESPACE_HERE/$name_space/" Problem.cs
sed -i "s|LEETCODE_LINK_HERE|${ql}|" Problem.cs
sed -i "s/NAMESPACE_HERE/$name_space/" Tests.cs

print_message "Generating problem complete!"
