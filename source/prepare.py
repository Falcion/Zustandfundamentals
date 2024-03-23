import os
import shutil

from bs4 import BeautifulSoup

"""
The MIT License (MIT)

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

- https://choosealicense.com/licenses/mit
- https://spdx.org/licenses/MIT

Copyright 2023-2024 (c) Falcion
"""

ENABLED = True

_root = './../'

"""
Remove HTML tags from a given HTML file and save the cleaned text back to the same file.

:param filepath: The path to the HTML file to be processed.
"""
def remove_html(filepath):
    with open(filepath, 'r') as f:
        soup = BeautifulSoup(f, 'html.parser')
        text = soup.get_text()
        
        with open(filepath, 'w') as _f:
            _f.write(text)


"""
Copy specified files to the current directory and parse HTML content from them using parsing function.

Args:
:param files: List of filenames to be copied and parsed.
"""
def copy_parse(files):
    for file in files:
        shutil.copy(_root + file, './')

        remove_html(os.path.join('./'), file)


# Default files that must be copied and parsed everytime, they are included (often)
# in .CSPROJ include requirements before publishing anything and/or building.
copy_parse(['README.md', 'LICENSE.md', 'CHANGELOG.md'])

while ENABLED:
    choice = input('Do you want to clone and parse other files? (Y/N): ')

    if(choice.upper() == 'Y'):
        filename = input('Enter filename of the file to clone (with extension): ')

        copy_parse([filename])
    elif choice.upper() == 'N':
        break
    else:
        print('Invalid choice.')


print('Files copied and parsed successfully into the source directory of project.')
