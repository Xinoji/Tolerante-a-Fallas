var http = require('http');
var request=0;
var podname = process.env.HOSTNAME;
var startTime;
var host;
var handleRequest = function(request, response){
    response.setHeader('Content-Type', 'text/plain');
    response.write("Intento desesperado que mi compu no explote, en host: ");
    response.write(host);
    response.end("\n");
    console.log("Host :", host, "| Total Requests: ", ++request, "| App Uptime:", (new Date() - startTime/1000 , "seconds", "| log time:", new Date()));
}
var www = http.createServer(handleRequest);
www.listen(8080,function(){
    startTime = new Date();;
    host = process.env.HOSTNAME;
    console.log("Aplicacion iniciada en: [",startTime,"] | Host: [",host,"]\n");
})