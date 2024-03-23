import os
import json

"""
The MIT License (MIT)

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

- https://choosealicense.com/licenses/mit
- https://spdx.org/licenses/MIT

Copyright 2023-2024 (c) Falcion
"""

_root = './../'

"""
Update the specified tag in .CSPROJ files with the provided data.

Args:
param: tag (list): The start and end tags to be updated.
param: data (str): The new data to replace the tag content.

Returns:
    None
"""
def enter_version(tag, data):
    mkdir_files = os.listdir()

    filtered = [filename for filename in mkdir_files if filename.endswith(".csproj")]

    for file in filtered:
        with open(file, 'w+') as _f:
            file_content = _f.read()

            lines = file_content.split('\n')

            for i, line in enumerate(lines):
                if tag[0] in line or tag[1] in line:
                    lines[i] = ' ' * 4 + f'{tag[0]}{data}{tag[1]}'

            _f.write(''.join(lines, '\n'))


VERSION_CONTAINERS = ['manifest.json', 'package.json']

for container in VERSION_CONTAINERS:
    if not os.path.exists(_root + container):
        continue
    else:
        with open(_root + container, 'r') as raw:
            data = json.load(raw)

            version = data.get('version')
            # Update version in .CSPROJ
            enter_version(['<Version>', '</Version>'], version)
            
            break



