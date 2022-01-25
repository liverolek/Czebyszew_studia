cd GrpcGreeter
dotnet build
cd ./bin/Debug/net6.0
for i in 5020 5021 5022 5023
do
   echo i
   dotnet GrpcGreeter.dll $i &
done
# cd ../../../../GrpcGreeterClient
# dotnet build
# cd ../
# cd ./GrpcGreeterClient/bin/Debug/net6.0/GrpcGreeterClient.dll ./
# dotnet GrpcGreeterClient.dll 5020 5021 5022 5023