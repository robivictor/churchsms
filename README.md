# churchsms
A web based easy membership and texting interface based on an android mobile gateway 

This web based application works with an opensource android based sms gateway
called EnvayaSMS.

The web interface:

1. Create a database on MsSQL server and with the name church_sms
2. Run the script found inside 'resources'/database_script.sql on this database
3. Update the connection string inside the web.confing file found inside the folder 'Web'. 
4. The first time you open the project inside visual sudio, dependecies will be downloaded from the cloud so be connected to the internet.
4. Set the web as a startup project and launch it from with in Visual studio.
5. Use the following user: 
   username: admin
   password: churchsms
   

The mobile gateway app

1. The mobile app can be downloaded here https://sms.envaya.org/
2. Set the servel url inside the settings of the app to 
   192.168.1.1:8080/api/gateway/
   where the ip and the port is at which the web application runs on, u just add /api/gateway on it.
   

