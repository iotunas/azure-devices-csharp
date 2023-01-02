Contributing
============
First off, thanks for taking the time to contribute!

The following is a set of guidelines for contributing to the repository and its packages.
These are mostly guidelines, not rules. 
Use your best judgment, and feel free to propose changes to this document in a pull request.

Contents:
- [Contributing](#contributing)
  - [How can I contribute?](#how-can-i-contribute)
    - [Reporting bugs](#reporting-bugs)
    - [Requesting new features](#requesting-new-features)
  - [Versioning](#versioning)
  - [Git commit messages](#git-commit-messages)
  - [Git branching strategy](#git-branching-strategy)
    - [**Main** - One to rule them all](#main---one-to-rule-them-all)
    - [**Development** - Code integration happens here](#development---code-integration-happens-here)
    - [**Working** - Here is where the magic happens](#working---here-is-where-the-magic-happens)
    - [**Experimental** - Temporary branches](#experimental---temporary-branches)
  - [Workflows](#workflows)
    - [Feature development](#feature-development)
    - [Release process](#release-process)
    - [Hot fixing process](#hot-fixing-process)
  - [Styleguides](#styleguides)
    - [Csharp styleguide](#csharp-styleguide)
    - [Documentation styleguide](#documentation-styleguide)
  - [Labels](#labels)
      - [Generic labels](#generic-labels)
      - [Priority labels](#priority-labels)
      - [Effor level labels](#effor-level-labels)
      - [Status labels](#status-labels)

How can I contribute?
---------------------

### Reporting bugs
Bugs are tracked as issues. 
Before submiting your bug report, please ensure no similar issues have been reported already.
Submit your bug report using the provided template to provide us with enough information to solve it as fast as possible.

### Requesting new features
Features are reported as issues.
Submit your feature request by using the provided feature request template.

Versioning
----------
We follow a basic [semantic versioning](https://semver.org/).
Where X.Y.Z represents a version number:
- X is the MAYOR version, usually migrations and breaking changes.
- Y is the MINOR version, feature and funcitonallity additions with backwards compatibility.
- Z is the PATCH version, bug fixes, performance issues, refactoring, etc.

Git commit messages
-------------------
- Use the imperative mood for subjects (If applied, this commit will [commit-message-here]).
- Whenever possible reference the issue or pull request by providing the id after a pound sign. (i.e `fix: #42 Add missing semicolon`).
- Consider starting the commit message with an applicable prefix, see below).

| Prefix     | Description |
| :-         | :-          |
| `feat:`    | Used when including additional functionality or features.
| `fix:`     | Used when fixing a bug. If an issue is related to it, include it in the message.
| `docs:`    | Used when adding or updating documentation. If documentation request is related to it, include it in the message.
| `test:`    | Used when adding or updating tests.
| `refact:`  | Used when refactoring code. Modifying the code without changing the "under the hood" implementation to improve readability, cohesion, coupling, duplication, etc. (i.e. The renaming variables, moving classes into multiple files, etc).
| `clean:`   | Used when applying changes to comply with style guidelines or general code cleanup. (i.e. Indentation changes, brackets alignment, etc).

Git branching strategy
----------------------
This section explains the different type of branches allowed in the repository.
This will help differentiate between the different branches and easily identify the kind of work being done overall in the repository.
The following table presents a resume of the strategy, for a detailed explanation on each branch keep scrolling.

| Type         | Name                             | Checkout from | Merges into |
| :-           | :-                               | :-            | :-          |
| Main         | `main`                           | None          | None
| Development  | `develop`                        | `main`        | `main`
| Working      | `develop/#`                      | `develop`     | `develop`
| Experimental | `exp/#`                          | Any           | None

### **Main** - One to rule them all
- *Naming*: `main` (aka `master`).
- *Description*: This is considered the most up-to-date and stable version of the repository.
- *Lifetime*: Eternal, never deleted
- *Created from*: None
- *Merges into*: None
- *Details*:
  - There shall only exist one `main` branch per repository.  
  - Never push commits directly to this branch, except when initially setting up a repository.
  - No direct commits are allowed here

### **Development** - Code integration happens here
- *Naming*: `develop` (aka `dev`, `development`).
- *Description*: Point of integration for all features.
- *Lifetime*: Eternal, never deleted
- *Created from*: `main`
- *Merges into*: None
- *Notes*:
  - Only one `develop` branch shall exist at any given time.
  - Direct commits are only allowed by maintainers, but the recommendation is using a proper issue branch.

### **Working** - Here is where the magic happens
- *Naming*: The recommendation is appending to the branch name (`develop/#`) a tag related the work been done in it and the user doing it. For example: `develop/issue-42` to demonstrate work on the issue, `develop/john-doe` to demonstrate work by John Doe.
- *Created from*: `develop` 
- *Merges into*: `develop`
- *Lifetime*: Short lived, deleted after PR
- *Notes*:
  - In some cases, the branch you want to work on already exists we encourage you to pick a different one.
  - Alternatively, contact the person working on the other branch and align up to cooperate on it.
  - At the very least, append a dash followed by your username if you still decide to work on this. 

### **Experimental** - Temporary branches
- *Naming*: `exp/#` where `#` is a unique name to identify the experiment.
- *Created from*: Any
- *Merges into*: None
- *Lifetime*: Variable
- *Notes*:
  - This branches are entirely meant for breaking changes. 
  - Feel free to use them to mess around and do research for specific features. 
  - Use them to share code or snippets with colleages.

Workflows
---------

### Feature development
1. Select a feature you wish to develop. You can find them with with the `feature` label in the issues section.
2. Verify no one is working on the feature already. 
  1. You can do this by checking the branches in the repo.
  2. If there is already someone working on the feature, consider looking for a different feature. 
  3. If you still insist in taking up on that feature, consider at the very least contacting him/her to collaborate. 
3. Pull your branch from `develop`. 
4. Do the proper changes
  1. Remeber to follow the style guidelines.
  2. Document your code.
  3. Add unit testing accordingly.
5. Create a pull request using the feat integration template.
6. If the PR is denied, perform the required changes and push them again.

### Release process
1. Milestones are achieved after enough features have been added.
2. Maintainers ensure release consistency.
  1. Version in .csproj is up to date.
  2. Change log has been updated with the current changes.
3. Maintainers create a PR from develop to main.
  3. Requires approval from all maintainers.
4. The `develop` branch is emrged with `main`.
5. Tags are updated in the `main` branch with the latest commit with the value of the version.
6. Artifact is build and published in github releases.
7. Artifcat is build as nuget packaged and published in nuget packages.

### Hot fixing process
1. Select the bug you wish to work on from the issues section, with the `bug` label.
2. Verify no one is working on the bug already. 
  1. You can do this by checking the branches in the repo.
  2. If there is already someone working on the bug, consider looking for a different feature. 
  3. If you still insist in taking up on that bug, consider at the very least contacting him/her to collaborate. 
3. Pull your branch from the current version of `main`.
4. Do the proper changes
  4. Remeber to follow the style guidelines.
  5. Document your code.
  6. Add unit testing accordingly.

Styleguides
-----------

### Csharp styleguide
- End the file with a line break. It makes it easier to append new data from the cli (if ever required to).
- Follow the best practices.
- Prefer block scoped namespace.
- Prefer namespace level using statements.
- Generally, use the `.editorconfig` for the underlying rules. Modify thorugh a PR as needed.

### Documentation styleguide
- Use markdown for documentation.
- Use a single `h1` header per documentation file.
- Preffer the use of `===` over `#` for `h1` headers.
- Preffer the use of `---` over `##` for `h2` headers.
- Preffer the use of `-` over `*` and `+` for unordered lists.
- Use ` ``` ` followed by the code language for code blocks.
- Use `> #### ` followed by `NOTE`, `WARNING`, or `IMPORTANT` to highlight statements.

Labels
------

#### Generic labels
Use this labels for the tagging and categorizing of issues and pull requests.
Add as many of these as required.

| Color   | Label | Description |
| :-      | :-    | :-          |
| #9F2B00 | `bug` | Indicates something related to a bug-report.
| #489C17 | `feature` | Indicates something related to a feature request. 
| #0000FF | `documentation` | Indicates a need for improvements or additions to documentation.
| #523A28 | `cicd` | Indicates anything related to the CI/CD workflows.
| #18DDF0 | `tests` | Indicates issues involved with tests.

#### Priority labels
Uses the Eisenhower Decision Principle.
This labels must be provided in pairs, always *importance* + *urgency*.
The *importance* determines how likely is the issue to affect long-term goals or milestones.
The *urgency* determines how much of a fast response is required.
The resulting combination dictates the action to take with the issue:
- `importance-high` + `urgency-high` = Must be done asap
- `importance-high` + `urgency-low` = Schedule them to be done in a calm and proper matter
- `importance-low` + `urgency-high` = Delegate to someone that can approach the issue asap
- `importance-low` + `urgency-low` = Won't do

| Color   | Label | Description |
| :-      | :-    | :-          |
| #C85250 | `importance-high` | Issue is likely to block/affect future work.
| #F7BEC0 | `importance-low` | Issue won't affect future work in a negative way. 
| #C85250 | `urgency-high` | Issue has a close deadline, or asap attention.
| #F7BEC0 | `urgency-low` | Issue deadline is far away.

#### Effor level labels
Based of the Cynefin framework. 
This label dictates the level of effor for a specific issue.
The more *disorder* the label indicates, the more knowledge is required to solve it.
Project managers and architects as well as the author of the issue should be able to 
work together to break down highly disorderd issues into smaller ones with a specific
target in it. The amount of breakdown needed is directly dependand on the experience
of the technical team working in the project. For example, a senior developer might
be able to take *complex* tasks, whereas a junior developer will require the task 
to be broken down into *simple* tasks in order for them to accomplish it correctly.

| Color   | Label | Description |
| :-      | :-    | :-          |
| #E6E6FA | `effort-simple`      | Consists of "known knowns". The cause and effect relationship is clear: if you do X, expect Y.
| #B1B1B1 | `effort-complicated` | Consists of "known unknowns". The cause and effect relationship requires analysis or expertise.
| #747474 | `effort-complex`     | Consists of "unknown unknowns". The cause and effect relationship can only be deduced in retrospect.
| #444444 | `effort-chaotic`     | Issue is "too confusing to wait for a knowledge-based response". The cause and effect relationship is unclear.
| #0A0708 | `effort-unknow`    | Issue with no clarity of which kind of consistency or work applies. 

#### Status labels
Based of the basic Kanban framework. 
This label dictates the status of a current issue.
Ultimately issues are open or closed, but there are also intermediate states that 
are required to be labeled for better tracking. Feel free to add as many as you need,
since this depends on the available environments for the project, and the project itself.

| Color   | Label | Description   |
| :-      | :-    | :-            |
| #00B140 | `status-ongoing`     | The issue is moving towards completion as there is work being made to solve it.
| #FBB80F | `status-testing`     | A solution for the issue has been provided and we are awaiting resolution on the implementation.
| #DC143C | `status-blocked`     | The issue is blocked and unable to work on due to a different open issue in the repository.
| #008672 | `status-help` | Issue requires help from external parties.
| #E4E669 | `status-deprecated`  | Issue is irrelevant due to a recent commit, pull request or update deprecating it.
