# goSolve - Review Dummy Api
This is a dummy api for template and example purposes.

## Requirements
Make sure to clone our [Development repository](https://github.com/gosolve-org/Development) and follow the setup instructions.

## First time API setup
We need to copy the generated root certificate into our project:
```shell
cp -a ~/.dev/gosolve/certs/. ./certs/
```

## Running the API
**First** make sure the shared docker-compose from the [Development repository](https://github.com/gosolve-org/Development) is running.

**The next step** is running the project:  
| Method | Description |
| ------ | ----------- |
| Visual Studio (easiest)   | Run the docker-compose project in Visual Studio. (This also enables debugging features.) |
| Terminal | Run `docker-compose up` in a terminal in the project directory. |  

:x: On errors, try removing your /obj and /bin folders. 

## License
[![License: AGPL v3](https://img.shields.io/badge/License-AGPL_v3-blue.svg)](https://www.gnu.org/licenses/agpl-3.0)  
goSolve is open-source. We use the [GNU AGPLv3 licensing strategy](LICENSE).
