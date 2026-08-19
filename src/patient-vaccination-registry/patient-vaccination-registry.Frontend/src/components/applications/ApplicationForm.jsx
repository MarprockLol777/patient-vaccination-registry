import { useState, useEffect } from "react";
import { applicationService, personService, vaccineService, driveService } from "../../services/api";

function ApplicationForm({ onApplicationCreated, editData }) {
    const [persons, setPersons] = useState([]);
    const [vaccines, setVaccines] = useState([]);
    const [drives, setDrives] = useState([]);

    const [form, setForm] = useState({
        personId: editData?.personId || "",
        vaccineId: editData?.vaccineId || "",
        driveId: editData?.driveId || "",
        applicationDate: editData?.applicationDate ? editData.applicationDate.split("T")[1]?.slice(0, 5) : "",
        doseNumber: editData?.doseNumber || ""
    });

    useEffect(() => {
        personService.getAll().then(data => setPersons(data));
        vaccineService.getAll().then(data => setVaccines(data));
        driveService.getAll().then(data => setDrives(data));
    }, []);

    const handleChange = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        const payload = {
            personId: parseInt(form.personId),
            vaccineId: parseInt(form.vaccineId),
            driveId: parseInt(form.driveId),
            applicationDate: `1970-01-01T${form.applicationDate}:00`,
            doseNumber: parseInt(form.doseNumber)
        };
        if (editData) {
            applicationService.update(editData.id, payload).then(() => onApplicationCreated());
        } else {
            applicationService.create(payload).then(() => onApplicationCreated());
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h3>{editData ? "Edit Application" : "Add Application"}</h3>
            <select name="personId" value={form.personId} onChange={handleChange} required>
                <option value="">Select Person</option>
                {persons.map(p => <option key={p.id} value={p.id}>{p.name}</option>)}
            </select>
            <select name="vaccineId" value={form.vaccineId} onChange={handleChange} required>
                <option value="">Select Vaccine</option>
                {vaccines.map(v => <option key={v.id} value={v.id}>{v.name}</option>)}
            </select>
            <select name="driveId" value={form.driveId} onChange={handleChange} required>
                <option value="">Select Drive</option>
                {drives.map(d => <option key={d.id} value={d.id}>{d.name}</option>)}
            </select>
            <input name="applicationDate" type="time" value={form.applicationDate} onChange={handleChange} required />
            <input name="doseNumber" type="number" min="1" placeholder="Dose Number" value={form.doseNumber} onChange={handleChange} required />
            <button type="submit">{editData ? "Update" : "Save"}</button>
        </form>
    );
}

export default ApplicationForm;