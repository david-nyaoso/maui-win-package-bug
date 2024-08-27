# maui-win-package-bug
dotnet maui project that used to work in .net 8 but can not with .net 9 preview-7

# Steps to reproduce on your own.

This 2 projects are the same except that one (UsedToWork) targets net8.0 and the other (DoesntWork) net9.0 preview-7.

I created them from the command line using the following commands:

dotnet new sln -n maui-win-package-bug

dotnet new maui -n UsedToWork -o 8.0 -f net8.0
dotnet new maui -n DoesntWork -o 9.0 -f net9.0

dotnet sln add 8.0
dotnet sln add 9.0

dotnet restore -f

Open the sln in VS 2022
From main menu, select : Build > Configuration Manager
Make sure the Deploy checkbox is ticked for the 'UsedToWork' project.


Add the below xml fragment to Application Node in Package.appxmanifest file in the Platforms/Windows directory.

 <Application Id="App" Executable="$targetnametoken$.exe" EntryPoint="$targetentrypoint$">
        ...
      <Extensions>
        <uap:Extension Category="windows.protocol">
          <uap:Protocol Name="myapp">
            <uap:DisplayName>myapp</uap:DisplayName>
          </uap:Protocol>
        </uap:Extension>
      </Extensions>
</Application>

Check the code file, PackageHelpers.cs, in Platforms\Windows folder.

I have also added a button in MainPage.xaml and code in to call a function in
PackageHelpers.cs. CLick on the button. The results show that when the app is unpackaged, you can not
access global::Windows.ApplicationModel.Package API.