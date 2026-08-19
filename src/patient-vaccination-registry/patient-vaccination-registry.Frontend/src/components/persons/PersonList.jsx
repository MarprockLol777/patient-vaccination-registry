import { useEffect, useState } from "react";
import { personService } from "../../services/api";

function PersonList({ refresh, onEdit }) {
    const [persons, setPersons] = useState([]);

    useEffect(() => {
        personService.getAll().then(data => setPersons(data));
    }, [refresh]);

    const handleDelete = (id) => {
        if (confirm("Are you sure?")) {
            personService.delete(id).then(() =>
                setPersons(prev => prev.filter(p => p.id !== id))
            );
        }
    };

    return (
        <table>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>ID Number</th>
                    <th>Birth Date</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {persons.map(p => (
                    <tr key={p.id}>
                        <td>{p.id}</td>
                        <td>{p.name}</td>
                        <td>{p.idNumber}</td>
                        <td>{p.birthDate ? p.birthDate.split("T")[0] : ""}</td>
                        <td>
                            <button className="btn-edit" onClick={() => onEdit(p)}>Edit</button>
                            <button className="btn-delete" onClick={() => handleDelete(p.id)}>Delete</button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
}

export default PersonList;