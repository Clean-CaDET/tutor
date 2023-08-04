from generator import generateFiles

def main():
    paths, typeOfService, labels = defineLabels()
    generateFiles(paths, typeOfService, labels)

def defineLabels():
    print("This script generates the starting classes for a new set of use cases (Ctrl+C to exit).")
    role = getRole()
    module = getModule()
    useCaseGroup = getUcGroup()
    typeOfService = getTypeOfService()
    mainEntityName = input("Enter the default name used for the generated classes: ").title().strip()
    
    paths = {
        "controller": f"Tutor.API/Controllers/{role}/{useCaseGroup}/{mainEntityName}Controller.cs",
        "apiInterface": f"Modules/{module}/Tutor.{module}.API/Public/{useCaseGroup}/I{mainEntityName}Service.cs",
        "apiDto": f"Modules/{module}/Tutor.{module}.API/Dtos/{mainEntityName}Dto.cs",
        "coreDomain": f"Modules/{module}/Tutor.{module}.Core/Domain/{mainEntityName}.cs",
        "coreRepo": f"Modules/{module}/Tutor.{module}.Core/Domain/I{mainEntityName}Repository.cs",
        "coreUseCase": f"Modules/{module}/Tutor.{module}.Core/UseCases/{useCaseGroup}/{mainEntityName}Service.cs",
        "infraRepo": f"Modules/{module}/Tutor.{module}.Infrastructure/Database/Repositories/{mainEntityName}Repository.cs",
        "test.command": f"Modules/{module}/Tutor.{module}.Tests/Integration/{useCaseGroup}/{mainEntityName}CommandTests.cs",
        "test.query": f"Modules/{module}/Tutor.{module}.Tests/Integration/{useCaseGroup}/{mainEntityName}QueryTests.cs"
    }
    
    response = confirmLabels(typeOfService, paths)
    if(response != "y"):
        exit()
        
    labels = {
        "role": role,
        "module": module,
        "useCaseGroup": useCaseGroup,
        "mainEntityName": mainEntityName
    }
        
    return paths, typeOfService, labels

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
    print("What type of application service do you need?")
    print("- Base service (default) [B]")
    print("- CRUD service (focused on one entity, starts with most CRUD operations) [c]")
    return input("Response: ").lower() or "b"

def confirmLabels(typeOfService, paths):
    print("The following files will be created:")
    print("\t"+paths["controller"])
    print("\t"+paths["apiDto"])
    print("\t"+paths["apiInterface"])
    print("\t"+paths["coreDomain"])
    if(typeOfService != "c"):
        print("\t"+paths["coreRepo"])
    print("\t"+paths["coreUseCase"])
    if(typeOfService != "c"):
        print("\t"+paths["infraRepo"])
    print("\t"+paths["test.command"])
    print("\t"+paths["test.query"])
    return input("\nDoes this look good [Y/n]: ").lower() or "y"

main()
