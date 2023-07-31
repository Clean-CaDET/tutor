import os
from pathlib import Path

def generateFiles(paths, typeOfService, mainEntityName):
    templates = Path("templates/")
    root = Path("../../src/")
    
    generateFile(root + paths["controller"], template+"Controller.cs", mainEntityName)
    generateFile(root + paths["apiInterface"], template+"Api.Interface.cs", mainEntityName)
    generateFile(root + paths["apiDto"], template+"Api.Dto.cs", mainEntityName)
    generateFile(root + paths["coreDomain"], template+"Core.Domain.cs", mainEntityName)
    generateFile(root + paths["coreRepo"], template+"Core.Repo.cs", mainEntityName)
    if(typeOfService == "c"):
        generateFile(root + paths["coreUseCase"], template+"Core.CrudUseCase.cs", mainEntityName)
    elif(typeOfService == "b"):
        generateFile(root + paths["coreUseCase"], template+"Core.BaseUseCase.cs", mainEntityName)
    else:
        generateFile(root + paths["coreUseCase"], template+"Core.UseCase.cs", mainEntityName)
    generateFile(root + paths["infraRepo"], template+"Infra.Repo.cs", mainEntityName)
    generateFile(root + paths["test"], template+"Tests.cs", mainEntityName)

def generateFile(outputName, templateName, mainEntityName):
	template = open(templateName,"r", encoding="utf8").read()
    
    os.makedirs(os.path.dirname(outputName), exist_ok=True)
	with open(outputName, "w", encoding="utf8") as output:
		output.write(template.replace("$$NAME$$", mainEntityName)))
	
def generateAll(folder, list):
	if not os.path.exists(folder):
		os.makedirs(folder)
	candidates = open(list, "r", encoding="utf8")
	for candidate in candidates:
		time.sleep(2)
		name, surname, points = candidate.strip().split(":")
		points = int(points)
		outputFile = folder + "/" + name + "-" + surname + ".txt"
		if points < 15:
			generateOutput(outputFile, "templates/below20.txt", name, points)
