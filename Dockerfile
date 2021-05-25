# base image
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

# baby of mkdir and cd
WORKDIR /patrickspeppers

COPY .sln ./
COPY PPBL/.csproj PPBL/
COPY PPDL/.csproj PPDL/
COPY PPUI/.csproj PPUI/
COPY PPModels/*.csproj PPModels/

#Restores any deps that we would need
# if the csproj files have not changed since the last build
# on this laptop, then, the above layers will be recovered from cache,
# and we don't need to run restore again.
RUN cd PPUI && dotnet restore

# we use .dockerignore to hide files from being copied with
# the build context, so COPY here won't see them either.
# which files? bin/, obj/, etc.

# copy the source code
COPY . ./
# CMD /bin/bash

# Publishes the application and its dependencies to a folder for deployment to a hosting system.
RUN dotnet publish PPUI -c Release -o publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as runtime

WORKDIR /patrickspeppers
# From the build stage, I wanna get the published version of my app
COPY --from=build /patrickspeppers/publish ./

CMD ["dotnet", "WebUI.dll"]
#this final image does not have the SDK, nor the src code, only
# 1 what's in the base image (the runtime)
# 2 my published build output

