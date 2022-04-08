INSERT INTO public."AssessmentItems"(
    "Id", "KnowledgeComponentId", "Order")
VALUES (-2111, -211, 10);
INSERT INTO public."ArrangeTasks"(
    "Id", "Text")
VALUES (-2111, 'Prateći kod predstavlja primer čiste funkcije.

    public List<Doctor> GetSuitableDoctors(Operation operation){{
    	List<Doctor> doctors = doctorRepository.FindAll();
    
    	List<Doctor> suitableDoctors = new ArrayList<>();
    	foreach(Doctor doctor in doctors){{
    		if(IsCapable(doctor, operation.GetRequiredCapabilities())
    		    && IsAvailable(doctor, operation.GetTimeSlot())){{
    			suitableDoctors.Add(doctor);
    		}}
    	}}
    
    	return suitableDoctors;
    }}

Rasporedi zahteve za izmenu softvera tako da su vezani za funkcije koje bismo verovatno menjali da bismo ih ispoštovali.');
INSERT INTO public."ArrangeTaskContainers"(
    "Id", "ArrangeTaskId", "Title")
VALUES (-1, -2111, 'Nijedna od navedenih');
INSERT INTO public."ArrangeTaskElements"(
    "Id", "ArrangeTaskContainerId", "Text")
VALUES (-1, -1, 'Dopuni format data transfer objekta da prikaže podatke novoj klijentskoj aplikaciji.');
INSERT INTO public."ArrangeTaskContainers"(
    "Id", "ArrangeTaskId", "Title")
VALUES (-2, -2111, 'FindAll');
INSERT INTO public."ArrangeTaskElements"(
    "Id", "ArrangeTaskContainerId", "Text")
VALUES (-2, -2, 'Potrebno je sačuvati podatke o lekarima u NoSQL bazi umesto u SQL bazi.');
INSERT INTO public."ArrangeTaskContainers"(
    "Id", "ArrangeTaskId", "Title")
VALUES (-3, -2111, 'GetSuitableDoctors');
INSERT INTO public."ArrangeTaskElements"(
    "Id", "ArrangeTaskContainerId", "Text")
VALUES (-3, -3, 'Od mogućih, uvek odabrati lekara koji ima najveći stepen uspeha za dati tip operacije, a prvog kada je nerešeno.');
INSERT INTO public."ArrangeTaskContainers"(
    "Id", "ArrangeTaskId", "Title")
VALUES (-4, -2111, 'IsCapable');
INSERT INTO public."ArrangeTaskElements"(
    "Id", "ArrangeTaskContainerId", "Text")
VALUES (-4, -4, 'Za izazovnu operaciju je potreban hirurg koji je bar jednom izveo dati tip operacije.');
INSERT INTO public."ArrangeTaskContainers"(
    "Id", "ArrangeTaskId", "Title")
VALUES (-5, -2111, 'IsAvailable');
INSERT INTO public."ArrangeTaskElements"(
    "Id", "ArrangeTaskContainerId", "Text")
VALUES (-5, -5, 'Uzima u obzir da li je lekar na bitnom sastanku u traženo vreme.');
