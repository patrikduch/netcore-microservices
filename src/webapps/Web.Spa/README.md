The project contains a fake authorization system, so you can change it to Identity or another.

# Web.Spa

## Installation
	0. Install of the latest stable Node.js: https://nodejs.org/en/
	1. At the first run you must close the project if it runs in Visual Studio or another IDE. 
	Open project's folder in console and run command `npm install`.
	2. Type `npm run build:dev` for development, it will compile the main and vendor bundles.
	3. Build and run the project.

## Modify WebPack vendor config
	If you modify the WebPack vendor config, you must manually recompile the vendor bundle.
	Type `npm run build:dev` to do this.

## Known issues
	* WebPack Hot Module Replacement [HMR] doesn't work with IIS
	Will be fixed. Use Kestrel for development instead.
	* HTTP Error 500
	Probably you don't have the latest version of Node.js.
	* HTTP Error 502.5
	You must install the latest ".NET Core SDK" and ".NET Core Runtime" 
	using this link: https://dotnet.microsoft.com/download
	* HTTP error 500 when hosted in Azure
	Set the "WEBSITE_NODE_DEFAULT_VERSION" to 6.11.2 in the "app settings" in Azure.

## Other issues
	If you will have any issue with project starting, you can see errors in logs ("/logs" directory). 
	Also feel free to use the issue tracker: https://github.com/NickMaev/react-core-boilerplate/issues
	Don't forget to mention the version of the React Core Boilerplate in your issue (e.g. TypeScript, JavaScript).


## Requirements

### Python specification for npm run build

https://www.python.org/downloads/release/python-271/


```bash
npm config set python "C:\Python27\python.exe"
```




## App startup

### Run with  CLI
sudo dotnet run --project ./Web.Spa.csproj

## Deployment

### classic production build script
dotnet publish -c Release 

### more advanced production build script

dotnet publish [name].sln -c Release -o out

## Dockerization

### Build image

docker build -f Dockerfile -t docker-netcore-redux .


## SEO

### Sitemap
https://www.xml-sitemaps.com/details-aspnetcorereactreduxtemplate-env.eba-mcv635ym.eu-west-1.elasticbeanstalk.com-da438de8d.html


## FE

### dependencies

Loading spinners: react-spinners
https://www.npmjs.com/package/react-spinners


### google fonts

https://fonts.google.com/specimen/Lexend?preview.text_type=custom



