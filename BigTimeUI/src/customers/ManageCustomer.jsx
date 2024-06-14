import React, { useEffect } from 'react';
import { Link } from 'react-router-dom';
import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup';
import * as Yup from 'yup';
import { states } from '@/utility';
import { customerService, alertService } from '@/services';

function ManageCustomer({ history, match }) {
    const { id } = match.params;
    const isAddMode = !id;

    const validationSchema = Yup.object().shape({});

    const { register, handleSubmit, reset, setValue, errors, formState } = useForm({
        resolver: yupResolver(validationSchema)
    });

    const onSubmit = (data) => {
        return isAddMode
            ? createCustomer(data)
            : updateCustomer(id, data);
    }

    const createCustomer = (data) => {
        return customerService.createCustomer(data)
            .then(() => {
                alertService.success('Customer added', { keepAfterRouteChange: true });
                history.push('.');
            })
            .catch(alertService.error);
    }

    const updateCustomer = (id, data) => {
        return customerService.updateCustomer(id, data)
            .then(() => {
                alertService.success('Customer updated', { keepAfterRouteChange: true });
                history.push('..');
            })
            .catch(alertService.error);
    }

    useEffect(() => {
        if (!isAddMode) {
            customerService.getById(id).then(customer => {
                const fields = ['firstName', 'lastName', 'companyName', 'address.street', 'address.city', 'address.state', 'address.zip'];
                fields.forEach(field => {
                    if (field.startsWith('address.')) {
                        return setValue(field, customer.address[field.replace('address.', '')]);
                    }
                    return setValue(field, customer[field]);
                });
            });
        }
    }, []);

    return (
        <form onSubmit={handleSubmit(onSubmit)} onReset={reset}>
            <h1>{isAddMode ? 'Add Customer' : 'Edit Customer'}</h1>
            <div className="form-row">
                <div className="form-group col-md-6 col-12">
                    <label>First Name</label>
                    <input name="firstName" type="text" ref={register} className={`form-control ${errors.firstName ? 'is-invalid' : ''}`} />
                    <div className="invalid-feedback">{errors.firstName?.message}</div>
                </div>
                <div className="form-group col-md-6 col-12">
                    <label>Last Name</label>
                    <input name="lastName" type="text" ref={register} className={`form-control ${errors.lastName ? 'is-invalid' : ''}`} />
                    <div className="invalid-feedback">{errors.lastName?.message}</div>
                </div>
                <div className="form-group col-12">
                    <label>Company</label>
                    <input name="companyName" type="text" ref={register} className={`form-control ${errors.company ? 'is-invalid' : ''}`} />
                    <div className="invalid-feedback">{errors.company?.message}</div>
                </div>
                <div className="form-group col-md-6 col-12">
                    <label>Street</label>
                    <input name="address.street" type="text" ref={register} className={`form-control ${errors.street ? 'is-invalid' : ''}`} />
                    <div className="invalid-feedback">{errors.street?.message}</div>
                </div>
                <div className="form-group col-md-6 col-12">
                    <label>City</label>
                    <input name="address.city" type="text" ref={register} className={`form-control ${errors.city ? 'is-invalid' : ''}`} />
                    <div className="invalid-feedback">{errors.city?.message}</div>
                </div>
                <div className="form-group col-md-6 col-12">
                    <label>State</label>
                    <select name="address.state" ref={register} className={`form-control ${errors.state ? 'is-invalid' : ''}`}>
                        <option value=""></option>
                        {states.map((state) => (
                            <option key={state.abbreviation} value={state.abbreviation}>
                                {state.name}
                            </option>
                        ))}
                    </select>
                    <div className="invalid-feedback">{errors.state?.message}</div>
                </div>
                <div className="form-group col-md-6 col-12">
                    <label>Zip Code</label>
                    <input name="address.zip" type="text" ref={register} className={`form-control ${errors.zip ? 'is-invalid' : ''}`} />
                    <div className="invalid-feedback">{errors.zip?.message}</div>
                </div>
            </div>
            <div className="form-group">
                <button type="submit" disabled={formState.isSubmitting} className="btn btn-primary">
                    {formState.isSubmitting && <span className="spinner-border spinner-border-sm mr-1"></span>}
                    Save
                </button>
                <Link to={isAddMode ? '.' : '..'} className="btn btn-link">Cancel</Link>
            </div>
        </form>
    );
}

export { ManageCustomer };