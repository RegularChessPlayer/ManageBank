# ManageBank
Sistema para gerenciamento de caixas eletrônicos.

### Pre-Requisites

* Container postgres
* DotnetCore
* Angular Cli


### Start Apllication

* Run Migrations 
    * dotnet ef --startup-project ../AtlanticoBank.Application/ migrations add Initial 
    * dotnet ef --startup-project ../AtlanticoBank.Application/ database update

* Run Apllication

* Run npm i em ManageBank\Frontend\SignalR

* Run ng serve em ManageBank\Frontend\SignalR


