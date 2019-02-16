# Script Properties
Framework "4.5.2"
properties {
    $baseDirectory = Resolve-Path .\
    $sourceDirectory = "$baseDirectory\src"

    $company = "SparkleCreations"
    $product = "Jobcard"

    $outputDirectory = "$baseDirectory\artifacts"
    $packagesDirectory = "$sourceDirectory\packages"
    $packagesOutputDirectory = "$outputDirectory\packages"

    # msbuild settings
    $solution = "SparkleCreations.Jobcard.sln"
    $solutionFile = "$sourceDirectory\$solution"
    $verbosity = "normal"
    $buildConfiguration = "Release"
    $buildPlatform = "Any CPU"
    $version = "1.0.0"

    # tools
    $nugetExe = "$sourceDirectory\.nuget\nuget.exe"

    # database
    $databaseServer = "localhost\sqlexpress2016"
    $integratedSecurity = "Integrated Security=True"
}

# Script Tasks
task Default -depends Clean, Init, Compile, Unit-Test

task Clean {
    DeleteDirectory $outputDirectory\**

    @("bin","obj") | ForEach-Object {
        DeleteDirectory "$sourceDirectory\**\$_\"
    }
}

task Init {
    Assert(Test-Path $nugetExe) -failureMessage "Nuget command line tool is missing at $nugetExe"

    Write-Host "Creating build output directory at $outputDirectory"
    CreateDirectory $outputDirectory
}

task Restore-Packages {
    Exec { & dotnet restore $solutionFile }
}

task Clean-Packages {
    Remove-Item -Force -Recurse $packagesDirectory;
    CreateDirectory $packagesDirectory;
}

task Unit-Test -depends Compile {
    Exec {
        Get-ChildItem -Path "$sourceDirectory\*.Test*" | ForEach-Object { dotnet test $_.FullName }
    }
}

task Compile -depends Init, Restore-Packages, NpmInstall {
    Exec {
        dotnet build $solutionFile -c $buildConfiguration --version-suffix $version -v $verbosity
    }
}

task NpmInstall {
    Get-ChildItem -Path $sourceDirectory | `
        Where-Object { $_.PSIsContainer } | `
        Where-Object { Test-Path -Path "$($_.FullName)\package.json" } | `
        ForEach-Object { 
        Push-Location
        Set-Location -Path $_.FullName
        Exec {
            npm install
        }
        Pop-Location
    }
}


# Script Functions
function CreateDirectory($directory) {
    Write-Host "Creating $directory"
    New-Item $directory -ItemType Directory -Force | Out-Null
}

function DeleteDirectory($directory) {
    if(Test-Path $directory){
        Write-Host "Removing $directory"
        Remove-Item $directory -Force -Recurse | Out-Null
    } else {
        Write-Host "$directory does not exist"
    }
}

