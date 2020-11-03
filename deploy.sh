dotnet publish -c Release
docker build -t keepr ./bin/Release/netcoreapp3.1/publish
docker tag keepr registry.heroku.com/keepr2/web
docker push registry.heroku.com/keepr2/web
heroku container:release web -a keepr2
echo press any key
read end