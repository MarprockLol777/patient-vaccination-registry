import { useEffect, useState } from "react";
import { driveService } from "../../services/api";

function DriveList({ refresh, onEdit }) {
    const [drives, setDrives] = useState([]);

    useEffect(() => {
        driveService.getAll().then(data => setDrives(data));
    }, [refresh]);

    const handleDelete = (id) => {
        if (confirm("Are you sure?")) {
            driveService.delete(id).then(() =>
                setDrives(prev => prev.filter(d => d.id !== id))
            );
        }
    };

    return (
        <table>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Journey Name</th>
                    <th>Date</th>
                    <th>Location</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {drives.map(d => (
                    <tr key={d.id}>
                        <td>{d.id}</td>
                        <td>{d.name}</td>
                        <td>{d.date ? d.date.split("T")[0] : ""}</td>
                        <td>{d.location}</td>
                        <td>
                            <button className="btn-edit" onClick={() => onEdit(d)}>Edit</button>
                            <button className="btn-delete" onClick={() => handleDelete(d.id)}>Delete</button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
}

export default DriveList;