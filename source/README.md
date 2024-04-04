> This file is cloned from origin's README without any HTML and hyperlinks: for advanced version of it, check the repository itself.

About the project
-----------------

Via programming different software, scripts and apps, there is a requirement for non-static predefined instances of different values which contain pair, triad, quadra or singleton instances of given parameters with given type.

Project of this implements such simple, yet effecient containers for your data samples with advanced infrastructures and tuples support, but not only this, it also provides custom wrapper for dictionary which acts like jengas data structure.

### Built-with

Project is created and “written” with help of:

![NUGET](https://img.shields.io/badge/-nuget-004880?style=for-the-badge&logo=nuget&logoColor=white)\
![DOTNET](https://img.shields.io/badge/-dotnet-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)\
![CSHARP](https://img.shields.io/badge/-csharp-512BD4?style=for-the-badge&logo=csharp&logoColor=white)\
![PYTHON](https://img.shields.io/badge/-python-3776AB?style=for-the-badge&logo=python&logoColor=white)


Getting started
---------------

Before asking questions, read this block because here is all the primary information on the project, which can answer your future not-yet asked questions.

### Prerequisites

If you want to make a contribution to this project, these are following tech-requirements:

- Installed [Node.js](https://dotnet.microsoft.com/en-us/download/) on your desktop on which you will edit/setup this project;
- Installed [Python](https://www.python.org/) if you want to contribute to the scripts of this project (in terms of .PY scripts);


For usage of this project, you must have on your machine already installed:

- Any potentional IDE or text-editor with .NET native support (better if with support of NUGET), like [“Visual Studio”](https://visualstudio.microsoft.com/) and etc.;\
    https://visualstudio.microsoft.com/ \
    https://code.visualstudio.com/
- Installed [.NET SDK](https://dotnet.microsoft.com/en-us/download/) on your working machine: direct requirement BOTH for contributing and using the project.

### Installation

> Permission is granted for free use in any of your products.
>
If you want to use this project, there are multiple ways to download-and-use this project: two “official” and direct, so, let's start from simplest official path:


Process of installation within NUGET package manager in VS:

1. Open project in IDE with .NET native-support;
2. Use the specified package manager in your IDE (in VS - find this in upper hotbar):\
   if we talking about VS, load project via solution explorer and then proceed with "Project → Manage Nuget Packages" and then navigate through UI with help of:\
   https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-visual-studio/
3. Write the name of this package into packages browser;
4. download the required for you version through the menu and package is ready-to-use.

> If you are interested in importing DLL of this package into your project, read this article:\
> https://learn.microsoft.com/en-us/dotnet/standard/native-interop/native-library-loading/

Guidelines for direct-installation way:

1. Download last tag on project's repository, for the last ZIP-tarball link provided below:\
   [download latest release](https://github.com/Falcion/Zustandsmaschine/releases/latest/)
   - or just download the source-code through "Code → Download ZIP (or any option that you want)", and proceed to the next step;
2. Within downloaded ZIP (or project), clone everything and paste to the directory of your project via "copy+paste" procedure;
3. Add namespace as dependency for your own namespaces (in case if you cloned the source into your project) and the project is ready-to-use.

Guidelines for installation of source code of this project:

1. Clone the repository with any form of app which supports git (or CLI of this site), guide is attached:\
   https://www.howtogeek.com/451360/how-to-clone-a-github-repository/
2. Open it with any suitable for you editor and feel free to customize, update and/or contribute to this project[^2].

Usage
-----

Project is very simple and compact and always in ready-to-use in hard-code situations project: it provides to you simplestics containers for data.

- Data container:
  - P1: which contains `[1]` non-static data-value(s);
  - P2: which contains `[2]` non-static data-value(s);
  - P3: which contains `[3]` non-static data-values(s);
  - P4: which contains `[4]` non-static data-values(s);
- Jenga array:
  - which contains same data as named bricks structure;

Usage of this project is very easy and comfortable for common user, its not provided with any advanced code or anything, it just the "data" which user must interpretate as it wants.

1. Go to your project's directory and paste the contents of this template, which were installed with help of installation guides[^3];
2. Now, you can continue to work on your project with this template's data in it.

Roadmap
-------

- [x] Create basic repository infrastructure for this project, including:
  - [x] basic .MD documentations and dealings stuff (like README, LICENSE and etc.);
  - [x] scripts and actions within CI/CD for supporting high-quality of this project;
- [x] Write and publish the demo (pre-release) version of project, including the most basic logic of this one:
  - [x] P1: which contains `[1]` non-static data-value(s);
  - [x] P2: which contains `[2]` non-static data-value(s);
  - [x] P3: which contains `[3]` non-static data-values(s);
  - [x] P4: which contains `[4]` non-static data-values(s);
  - [x] ARR-JENGA:
    - [x] T1K1;
    - [x] T1K2;
    - [x] Thread-safe versions of them;
- [ ] Write the documentation for this demo-project and:
  - [ ] make it one as archive for technical docs purposes (hyperlinking directive);
- [ ] Refactor and prepare for “advancing” the project's logic and write an entire functionality of it.
- [ ] Refactor and prepare for “advancing” the project's documentation and publish it via the archive.

Contributing
------------

Contributions are what make open source community such an interest place to be in, so any form of contribution are greatly appreciated.

If you think that you can help this project become better but think its not so important/realizable in the current situtation or for a full contribution, use issues page, otherwise there is a guideline and policy for contributing.

If you want to contribute to this project, please, read contributioning policy and commit convention, this repository works with CLA, commits convention and on automated deployment system[^4].

> For one-single file contributioning, use a more quicker way without forking the repository through website.

More about it in this article:
- [“Working with forks”](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/working-with-forks/syncing-a-fork/) about syncing one-file fork;

License
-------

Project thanks the [Electron.js](https://github.com/electron/electron/) and [Angular.js](https://github.com/angular/angular/) for their amazing repository scripts and entire infrastructure, which partially were imported to this repository. 

> For individual licensing and credits information, seek correspondive files and/or sources.

Project itself is being distributed under the [MIT License](https://choosealicense.com/licenses/mit/) — see the file for more specified information.

Contact
-------

For any legal purposes, you can contact developer/maintainer through its e-mail:

<!-- Using "MAILTO" for better view of README -->

- <a href="mailto: io.falcion@outlook.com">Outlook E-mail</a>\
  You can also check contact information in [CODEOWNERS](./.github/CODEOWNERS) file within referencing our contacts.

If the developer/maintainer didn't answered, or you have other questions in nature, you can use issues page on this repository via specified templates or indirect self-written issue.

Acknowledgments
---------------

- https://shields.io/
- https://simpleicons.org/
- https://gitignore.io/
- https://gitattributes.io/
  - this generator is discontinued, use:\
    https://richienb.github.io/gitattributes-generator/
- [Best README template](https://github.com/othneildrew/Best-README-Template)

[^1]: For this, please, read [README](./main/README) and keep in mind, that this is a template and if you want to, you could redefine entire structure of this file or entire repository.
[^2]: for contributing policy, see — [CONTRIBUTING.md](./main/.github/CONTRIBUTING.md)
[^3]: [.../#installation](#installation)
[^4]: read the files of [commiting convention policy](./main/docs/github/COMMIT_CONVENTION.md) and [contributioning policy](./main/.github/CONTRIBUTING.md)
