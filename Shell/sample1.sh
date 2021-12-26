#!/bin/bash

for line in $(printenv)
do
    echo ${line}
done