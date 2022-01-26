cd GrpcGreeter
dotnet build
cd ./bin/Debug/net6.0
for i in 5020 5021 5022 5023 5024 5025 5026 5027
do
   echo i
   dotnet GrpcGreeter.dll $i &
done
