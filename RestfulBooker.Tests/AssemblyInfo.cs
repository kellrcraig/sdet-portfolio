[assembly: Parallelizable(ParallelScope.Fixtures)]

// Github hosted machines (ubuntu-latest or windows-latest) run on standarddized VMs with 2-core CPUs
[assembly: LevelOfParallelism(2)]