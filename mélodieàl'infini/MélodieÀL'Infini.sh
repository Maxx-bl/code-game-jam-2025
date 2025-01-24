#!/bin/sh
echo -ne '\033c\033]0;MélodieÀL'Infini\a'
base_path="$(dirname "$(realpath "$0")")"
"$base_path/MélodieÀL'Infini.x86_64" "$@"
