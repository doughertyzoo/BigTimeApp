import config from 'config';
import { httpHelper } from '@/utility';

const baseUrl = `${config.apiUrl}/customer`;

export const customerService = {
    getAll,
    getById,
    createCustomer,
    updateCustomer,
    deleteCustomer
};

function getAll() {
    return httpHelper.get(`${baseUrl}/get-all`);
}

function getById(id) {
    return httpHelper.get(`${baseUrl}/get/${id}`);
}

function createCustomer(params) {
    return httpHelper.post(`${baseUrl}/create`, params);
}

function updateCustomer(id, params) {
    return httpHelper.put(`${baseUrl}/update/${id}`, params);
}

function deleteCustomer(id) {
    return httpHelper.delete(`${baseUrl}/delete/${id}`);
}
