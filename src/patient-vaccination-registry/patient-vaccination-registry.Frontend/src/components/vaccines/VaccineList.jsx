import { useEffect, useState } from "react";
import { vaccineService } from "../../services/api";

function VaccineList({ refresh, onEdit }) {
    const [vaccines, setVaccines] = useState([]);

    useEffect(() => {
        vaccineService.getAll().then(data => setVaccines(data));
    }, [refresh]);

    const handleDelete = (id) => {
        if (confirm("Are you sure?")) {
            vaccineService.delete(id).then(() =>
                setVaccines(prev => prev.filter(v => v.id !== id))
            );
        }
    };

    return (
        <table>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Vaccine Name</th>
                    <th>Manufacturer</th>
                    <th>Batch</th>
                    <th>Required Doses</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {vaccines.map(v => (
                    <tr key={v.id}>
                        <td>{v.id}</td>
                        <td>{v.name}</td>
                        <td>{v.manufacturer}</td>
                        <td>{v.batch}</td>
                        <td>{v.requiredDoses}</td>
                        <td>
                            <button className="btn-edit" onClick={() => onEdit(v)}>Edit</button>
                            <button className="btn-delete" onClick={() => handleDelete(v.id)}>Delete</button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
}

export default VaccineList;