# SolrDotNet
Example of how to use Apache Solr using Dotnet


1) - Após ter instalado o apache Solr: https://solr.apache.org/downloads.html ou Docker: https://hub.docker.com/_/solr

2) - Criar o core usando o comando: 
solr create -c "nome-do-core-desejado" 

3) Após a criação do core, modificar o arquivo: "managed-schema.xml", que "fica na pasta de instalação do Solr/ "nome-do-core-desejado" 

  <field name="FieldForSearch" type="text_general" indexed="true" stored="true" required="true" multiValued="false"/>
  <field name="_nest_path_" type="_nest_path_"/>
  <field name="_root_" type="string" docValues="false" indexed="true" stored="false"/>
  <field name="_text_" type="text_general" multiValued="true" indexed="true" stored="false"/>
  <field name="_version_" type="plong" indexed="false" stored="false"/>
  <field name="id" type="string" multiValued="false" indexed="true" required="true" stored="true"/>

4) - Ir no Core Admin e dar um Reload

5) - Abra o projeto e vá em: appsettings.Development or appsettings e popule as informações, de acordo com a instalação do Apache Solr: 

 Ex:
  "Solr": {
    "Url": "http://localhost",
    "Core": "nome-do-core-desejado",
    "Port": "0000"
  },

Obs: caso não queira usar o appsettings basta preencher essas variaveis de ambiente: SolrUrl, SolrCore, SolrPort com seu respectivos valores.


#DotNet

