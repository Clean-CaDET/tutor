import os
from pathlib import Path

def generateFiles(paths, typeOfService, labels):
    templates = Path("templates/")
    root = Path("../../src/")
    
    generateFile(root / paths["apiDto"], templates/"Api.Dto.cs", labels)
    generateFile(root / paths["coreDomain"], templates/"Core.Domain.cs", labels)
    if(typeOfService == "c"):
        generateCrud(root, paths, labels, templates/"crud/")
    else:
        generateBase(root, paths, labels, templates/"base/")

def generateCrud(root, paths, labels, template):
    generateFile(root / paths["controller"], template/"Controller.cs", labels)
    generateFile(root / paths["apiInterface"], template/"Api.Interface.cs", labels)
    generateFile(root / paths["coreUseCase"], template/"Core.UseCase.cs", labels)
    generateFile(root / paths["test.command"], template/"Tests.Command.cs", labels)
    generateFile(root / paths["test.query"], template/"Tests.Query.cs", labels)
    
def generateBase(root, paths, labels, template):
    generateFile(root / paths["controller"], template/"Controller.cs", labels)
    generateFile(root / paths["apiInterface"], template/"Api.Interface.cs", labels)
    generateFile(root / paths["coreUseCase"], template/"Core.UseCase.cs", labels)
    generateFile(root / paths["coreRepo"], template/"Core.Repo.cs", labels)
    generateFile(root / paths["infraRepo"], template/"Infra.Repo.cs", labels)
    generateFile(root / paths["test.command"], template/"Tests.Command.cs", labels)
    generateFile(root / paths["test.query"], template/"Tests.Query.cs", labels)

def generateFile(outputName, templateName, labels):
    template = open(templateName,"r", encoding="utf8").read()
    template = template.replace("{{NAME}}", labels["mainEntityName"])
    template = template.replace("{{NAME_L}}", labels["mainEntityName"].lower())
    template = template.replace("{{USE_CASE}}", labels["useCaseGroup"])
    template = template.replace("{{USE_CASE_L}}", labels["useCaseGroup"].lower())
    template = template.replace("{{ROLE}}", labels["role"])
    template = template.replace("{{ROLE_L}}", labels["role"].lower())
    template = template.replace("{{MODULE}}", labels["module"])
    
    os.makedirs(os.path.dirname(outputName), exist_ok=True)
    with open(outputName, "w", encoding="utf8") as output:
        output.write(template)
