dotnet publish -c Release
docker build -t keepr ./
docker tag keepr registry.heroku.com/keeper2/web
docker push registry.heroku.com/keeper2/web
heroku container:release web -a keeper2
echo press any key
read end