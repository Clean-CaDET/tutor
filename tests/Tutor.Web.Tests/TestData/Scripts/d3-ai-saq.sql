INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
    (-212, -21, 12);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
    (-212, 'Iz sledećeg koda navedi sve nazive identifikatora (razdvojene zarezom) koji krše česte konvencije u pisanju programa.

public List<string> GetCamelCaseWords(List<string> Words)
{{
    List<string> camelCaseWords = new List<string>();
    foreach (string word in Words)
    {{
        var word_parts = Regex.Split(word, "[A-Z]");
        var matches = Regex.Matches(word, "[A-Z]");
        for (int idx = 0; idx < word_parts.Length - 1; idx++)
        {{
            word_parts[idx + 1] = matches[idx] + word_parts[idx + 1];
        }}
        camelCaseWords.AddRange(word_parts);
    }}

    return camelCaseWords;
}}', '{{"Words, word_parts, idx, abc"}}');


INSERT INTO public."AssessmentItems"("Id", "KnowledgeComponentId", "Order") VALUES
    (-995, -21, 13);
INSERT INTO public."ShortAnswerQuestions"("Id", "Text", "AcceptableAnswers") VALUES
        (-995, 'Posmatrajući sledeću strukturu paketa, navedi nazive klasa (razdvojene zarezom i bez .cs) koji krše konvenciju.

    - Hospital
    - Core
    - Patients
    - Model
    - Patient.cs
    - PatientRecord.cs
    - Repository
    - PatientRepository.cs
    - MedicalRecordService.cs
    - Physicians
    - Model
    - Physician.cs
    - Specialization.cs
    - Repository
    - PhysicianStorage.cs
    - PhysicianService.cs
    - Schedule
    - Model
    - PhysicianSchedule.cs
    - Appointment.cs
    - Repository
    - PhysicianScheduleRepository.cs
    - ScheduleService.cs
    - Controllers
    - PatientRecordController.cs
    - EmployeeController.cs
    - ScheduleController.cs', '{{"MedicalRecordService, PhysicianStorage"}}');