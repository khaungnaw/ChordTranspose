## Description  
This is simple console application that will help to **Transpose Music Chords**.  
It is built using **.NET 8 SDK** and supports **Ubuntu/Linux** installation.  

## Installation Guide  

### **Install .NET 8 on Ubuntu**  
Follow the steps below Run the following commands:  
#### Step 1: Install sudo (if not installed)
```sh
apt-get install sudo -y
```
#### Step 2: Install Microsoft Package Repository
```sh
apt-get update
sudo apt install lsb-release wget
wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```
#### Step 3: Install .NET SDK 8
```sh
sudo apt install -y dotnet-sdk-8.0
```
#### Step 4: Clone Git Repository
```sh
sudo apt install git
git clone https://github.com/khaungnaw/ChordTranspose.git
```
#### Step 5: Compiled Application And Run
```sh
dotnet build
dotnet run
```



