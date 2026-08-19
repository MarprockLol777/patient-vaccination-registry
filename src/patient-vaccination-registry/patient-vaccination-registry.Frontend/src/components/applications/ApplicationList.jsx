import { useEffect, useState } from "react";
import { applicationService, personService, vaccineService, driveService } from "../../services/api";

function ApplicationList({ refresh, onEdit }) {
    const [applications, setApplications] = useState([]);
    const [persons, setPersons] = useState([]);
    const [vaccines, setVaccines] = useState([]);
    const [drives, setDrives] = useState([]);

    useEffect(() => {
        applicationService.getAll().then(data => setApplications(data));
        personService.getAll().then(data => setPersons(data));
        vaccineService.getAll().then(data => setVaccines(data));
        driveService.getAll().then(data => setDrives(data));
    }, [refresh]);

    const getPersonName = (id) => persons.find(p => p.id === id)?.name || id;
    const getVaccineName = (id) => vaccines.find(v => v.id === id)?.name || id;
    const getDriveName = (id) => drives.find(d => d.id === id)?.name || id;

    const handleDelete = (id) => {
        if (confirm("Are you sure?")) {
            applicationService.delete(id).then(() =>
                setApplications(prev => prev.filter(a => a.id !== id))
            );
        }
    };

    return (
        <table>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Person Name</th>
                    <th>Vaccine</th>
                    <th>Drive</th>
                    <th>Time</th>
                    <th>Dose Number</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {applications.map(a => (
                    <tr key={a.id}>
                        <td>{a.id}</td>
                        <td>{getPersonName(a.personId)}</td>
                        <td>{getVaccineName(a.vaccineId)}</td>
                        <td>{getDriveName(a.driveId)}</td>
                        <td>{a.applicationDate ? a.applicationDate.split("T")[1]?.slice(0, 5) : ""}</td>
                        <td>{a.doseNumber}</td>
                        <td>
                            <button className="btn-edit" onClick={() => onEdit(a)}>Edit</button>
                            <button className="btn-delete" onClick={() => handleDelete(a.id)}>Delete</button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
}

export default ApplicationList;