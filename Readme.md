# Task Tracker

My solution for the [task-tracker](https://roadmap.sh/projects/task-tracker) challenge from [roadmap.sh](https://roadmap.sh/).

Built with dotnet 8

## How to run

Clone the repository and cd in to the project directory

```bash
git clone https://github.com/westkustdev/Task-Tracker.git
cd task-tracker
```

Run the following command to build and cd in to the output directory

```bash
dotnet build
cd task-cli/bin/Debug/net8.0
```

The following commands are available

```bash
./task-cli --help                      # To see the available commands

./task-cli add [description]           # To add a task with the given description

./task-cli delete [id]                 # To remove a task with the given id

./task-cli list                        # To list all tasks
./task-cli list [status]               # To list all tasks with the given status

./task-cli mark-[status] [id]          # To mark a task with the given id as the given status

./task-cli update [id] [description]  # To update a task with the given id
```

Available status are:
- todo
- in-progress
- done