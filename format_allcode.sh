#!/bin/sh -xe
find . -name '*.cs' | xargs -Iarg astyle -A14 --indent-namespaces --suffix=none arg
