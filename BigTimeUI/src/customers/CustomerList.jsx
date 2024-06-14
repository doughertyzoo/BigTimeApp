import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { customerService } from '@/services';

function CustomerList({ match }) {
    const { path } = match;
    const [customers, setCustomers] = useState(null);

    const deleteCustomer = (id) => {
        setCustomers(customers.map(x => {
            if (x.customerId === id) { x.isDeleting = true; }
            return x;
        }));
        customerService.deleteCustomer(id).then(() => {
            setCustomers(customers => customers.filter(x => x.customerId !== id));
        });
    };

    useEffect(() => {
        customerService.getAll().then(x => setCustomers(x));
    }, []);

    return (
        <div>
            <h1>Customers</h1>
            <Link to={`${path}/add`} className="btn btn-sm btn-success mb-2">Add Customer</Link>
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th style={{ width: '23%' }}>First Name</th>
                        <th style={{ width: '23%' }}>Last Name</th>
                        <th style={{ width: '23%' }}>Company</th>
                        <th style={{ width: '23%' }}>Address</th>
                        <th style={{ width: '8%' }}></th>
                    </tr>
                </thead>
                <tbody>
                    {customers && customers.map(customer =>
                        <tr key={customer.customerId}>
                            <td>{customer.firstName}</td>
                            <td>{customer.lastName}</td>
                            <td>{customer.companyName}</td>
                            <td dangerouslySetInnerHTML={{ __html: customer.address.addressBlock }} />
                            <td style={{ whiteSpace: 'nowrap' }}>
                                <Link to={`${path}/edit/${customer.customerId}`} className="btn btn-sm btn-primary mr-1">Edit</Link>
                                <button onClick={() => deleteCustomer(customer.customerId)} className="btn btn-sm btn-danger btn-delete-customer" disabled={customer.isDeleting}>
                                    {customer.isDeleting
                                        ? <span className="spinner-border spinner-border-sm"></span>
                                        : <span>Delete</span>
                                    }
                                </button>
                            </td>
                        </tr>
                    )}
                    {!customers &&
                        <tr>
                            <td colSpan="5" className="text-center">
                                <div className="spinner-border spinner-border-lg align-center"></div>
                            </td>
                        </tr>
                    }
                    {customers && !customers.length &&
                        <tr>
                            <td colSpan="5" className="text-center">
                                <div className="p-2">No Customers To Display</div>
                            </td>
                        </tr>
                    }
                </tbody>
            </table>
        </div>
    );
}

export { CustomerList };