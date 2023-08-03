from generator import generateFiles

def main():
    paths, typeOfService, mainEntityName = defineLabels()
    generateFiles(paths, typeOfService, mainEntityName)

def defineLabels():
    print("This script generates the starting classes for a new set of use cases (Ctrl+C to exit).")
    role = getRole()
    module = getModule()
    useCaseGroup = getUcGroup()
    typeOfService = getTypeOfService()
    mainEntityName = input("Enter the default name used for the generated classes: ").title().strip()
    
    paths = {
        "controller": f"\tTutor.API/Controllers/{role}/{useCaseGroup}/{mainEntityName}Controller.cs",
        "apiInterface": f"\tModules/{module}/Tutor.{module}.API/Interfaces/{useCaseGroup}/I{mainEntityName}Service.cs",
        "apiDto": f"\tModules/{module}/Tutor.{module}.API/Dtos/{mainEntityName}Dto.cs",
        "coreDomain": f"\tModules/{module}/Tutor.{module}.Core/Domain/{mainEntityName}.cs",
        "coreRepo": f"\tModules/{module}/Tutor.{module}.Core/Domain/I{mainEntityName}Repository.cs",
        "coreUseCase": f"\tModules/{module}/Tutor.{module}.Core/UseCases/{useCaseGroup}/{mainEntityName}Service.cs",
        "infraRepo": f"\tModules/{module}/Tutor.{module}.Infrastructure/Database/Repositories/{mainEntityName}Repository.cs",
        "test": f"\tModules/{module}/Tutor.{module}.Tests/Integration/{useCaseGroup}/{mainEntityName}Tests.cs"
    }
    
    response = confirmLabels(typeOfService, paths)
    if(response != "y"):
        exit()
        
    return paths, typeOfService, mainEntityName

def getRole():
    message = "Which role will invoke the new endpoint [L/i/a]: "
    response = input(message).lower() or "l"
    label_mapping = {
        "l": "Learner",
        "i": "Instructor",
        "a": "Administrator"
    }
    return label_mapping[response]

def getModule():
    response = None
    while(not response):
        print("What module will you primarily expand?")
        print("- Stakeholders [s]")
        print("- Courses [c]")
        print("- Knowledge Components [kc]")
        print("- Learning Utils [lu]")
        response = input("Response: ").lower() or None
    
    label_mapping = {
        "s": "Stakeholders",
        "c": "Courses",
        "kc": "KnowledgeComponents",
        "lu": "LearningUtils"
    }
    return label_mapping[response]

def getUcGroup():
    response = None
    while(not response):
        print("What is the primary use case group?")
        print("- Learning [l]")
        print("- Authoring [a]")
        print("- Monitoring [m]")
        print("- Analysis [an]")
        print("- Management [ma]")
        print("- New group [ng]")
        response = input("Response: ").lower()
        if(response == "ng"):
            message = "Name the new use case group: "
            response = input(message).title().strip() or "."
            return response
    label_mapping = {
        "l": "Learning",
        "a": "Authoring",
        "m": "Monitoring",
        "an": "Analysis",
        "ma": "Management"
    }
    return label_mapping[response]

def getTypeOfService():
    print("What type of coordinating service do you need?")
    print("- CRUD service (focused on one entity, requires most CRUD operations) [C]")
    print("- Base service (focused on one entity) [b]")
    print("- Empty service (focused on multiple entities) [m]")
    return input("Response: ").lower() or "c"

def confirmLabels(typeOfService, paths):
    print("The following files will be created:")
    print(paths["controller"])
    print(paths["apiDto"])
    print(paths["apiInterface"])
    print(paths["coreDomain"])
    if(typeOfService != "c"):
        print(paths["coreRepo"])
    print(paths["coreUseCase"])
    if(typeOfService != "c"):
        print(paths["infraRepo"])
    print(paths["test"])
    return input("\nDoes this look good [Y/n]: ").lower() or "y"

main()
