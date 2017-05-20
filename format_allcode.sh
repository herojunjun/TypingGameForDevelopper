#!/bin/sh -xe
find . -name '*.cs' | xargs -Iarg astyle -A14 --suffix=none arg
