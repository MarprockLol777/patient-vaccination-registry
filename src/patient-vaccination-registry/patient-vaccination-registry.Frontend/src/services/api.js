const API_URL = "https://localhost:7218/api";

export const personService = {
    getAll: () => fetch(`${API_URL}/persons`).then(r => r.json()),
    getById: (id) => fetch(`${API_URL}/persons/${id}`).then(r => r.json()),
    create: (data) => fetch(`${API_URL}/persons`, { method: "POST", headers: { "Content-Type": "application/json" }, body: JSON.stringify(data) }).then(r => r.json()),
    update: (id, data) => fetch(`${API_URL}/persons/${id}`, { method: "PUT", headers: { "Content-Type": "application/json" }, body: JSON.stringify(data) }),
    delete: (id) => fetch(`${API_URL}/persons/${id}`, { method: "DELETE" })
};

export const vaccineService = {
    getAll: () => fetch(`${API_URL}/vaccines`).then(r => r.json()),
    getById: (id) => fetch(`${API_URL}/vaccines/${id}`).then(r => r.json()),
    create: (data) => fetch(`${API_URL}/vaccines`, { method: "POST", headers: { "Content-Type": "application/json" }, body: JSON.stringify(data) }).then(r => r.json()),
    update: (id, data) => fetch(`${API_URL}/vaccines/${id}`, { method: "PUT", headers: { "Content-Type": "application/json" }, body: JSON.stringify(data) }),
    delete: (id) => fetch(`${API_URL}/vaccines/${id}`, { method: "DELETE" })
};

export const driveService = {
    getAll: () => fetch(`${API_URL}/drives`).then(r => r.json()),
    getById: (id) => fetch(`${API_URL}/drives/${id}`).then(r => r.json()),
    create: (data) => fetch(`${API_URL}/drives`, { method: "POST", headers: { "Content-Type": "application/json" }, body: JSON.stringify(data) }).then(r => r.json()),
    update: (id, data) => fetch(`${API_URL}/drives/${id}`, { method: "PUT", headers: { "Content-Type": "application/json" }, body: JSON.stringify(data) }),
    delete: (id) => fetch(`${API_URL}/drives/${id}`, { method: "DELETE" })
};

export const applicationService = {
    getAll: () => fetch(`${API_URL}/applications`).then(r => r.json()),
    getById: (id) => fetch(`${API_URL}/applications/${id}`).then(r => r.json()),
    create: (data) => fetch(`${API_URL}/applications`, { method: "POST", headers: { "Content-Type": "application/json" }, body: JSON.stringify(data) }).then(r => r.json()),
    update: (id, data) => fetch(`${API_URL}/applications/${id}`, { method: "PUT", headers: { "Content-Type": "application/json" }, body: JSON.stringify(data) }),
    delete: (id) => fetch(`${API_URL}/applications/${id}`, { method: "DELETE" })
};