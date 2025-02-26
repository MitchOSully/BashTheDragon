#!/bin/bash

# Have to unset IFS so that we get spaces in our file names. Will be restored at the end.
SAVEIFS=$IFS
IFS=$( echo -en "\n\b" )

# Loop through files in current directory
for file in *
do
	newFileName=""
	# Loop through characters
	for (( ii=0; ii<${#file}; ii++ )); do
		char="${file:$ii:1}"
		if [[ "$char" =~ \  ]]
		then
			newFileName="${newFileName}WAS"
		else
			newFileName="${newFileName}${char}"
		fi
	done

	# Rename file if newFileName is different
	if [ "$file" != "$newFileName" ]
	then
		echo "$file --> $newFileName"
		mv $file $newFileName
	fi
done

# Restore IFS
IFS=$SAVEIFS
