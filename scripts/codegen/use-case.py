import os
import shutil
from pathlib import Path

def main():
    template_folder = Path("templates/")
    destination_folder = Path("destination_folder/")

def interact():
    

    # Define the messages
    first_message = "Do you want to copy a file? [Y/n]: "
    second_message = """
    Select a label:
    1. label1
    2. label2
    3. label3
    4. label4
    """

    # Mapping for the labels
    label_mapping = {
        "1": "label1",
        "2": "label2",
        "3": "label3",
        "4": "label4"
    }

    # Ask the first question
    response = input(first_message).lower() or "y"
    if response == "y":
        # Copy the file
        shutil.copy(template_folder / "file.txt", destination_folder / "file.txt")
        print(f"File 'file.txt' copied to {destination_folder}")
    else:
        print("Aborted.")
        return

    # Ask the second question
    label_choice = input(second_message)
    label = label_mapping.get(label_choice)
    if label is None:
        print("Invalid choice.")
        return

    # Copy the file with the label
    shutil.copy(template_folder / "file.txt", destination_folder / f"{label}_file.txt")
    print(f"File 'file.txt' copied to {destination_folder / f'{label}_file.txt'}")


# Call the function
interact()
