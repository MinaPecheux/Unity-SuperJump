# [Unity/C#] Super Jump

**Mina Pêcheux - February 2022**

![Codemagic build status](https://api.codemagic.io/apps/620526c3546bd2c8549d973d/unity-mac-workflow/status_badge.svg)

This project is a sample demo for linking [Github **webhooks**](https://docs.github.com/en/github-ae@latest/developers/webhooks-and-events/webhooks) with [Codemagic workflows](https://unitycicd.com/), and for automatically **delivering the build artifacts** to a Slack channel.

🔴 _**Important note**: the repo doesn't use [Git LFS](https://github.com/git-lfs/git-lfs/tree/main) at the moment - but this tool would probably be required to really handle production assets and bigger binaries!_


🔵 _**Disclaimer**: this "game" is obviously just a prototype and this code is not really production ready... :)_

![demo](Docs/demo.gif)

---

This repo is meant to propose a basic CI/CD process to automate the integration of game art assets into a Unity game, and directly build a matching dev prototype so that artists can test the updated version without the help of the dev team.

The project relies on webhooks:

- any commit that is pushed on a branch which name follows the pattern: `feat-art/*` will trigger a new Codemagic build
- for now, this build is configured to produce a Mac `.app` artifact
- this artifact is then sent to a given Slack channel (here: an arbitrary `#test-codemagic-integration` channel in a Slack workspace that has been linked with the Codemagic account)
