import React from 'react'
import {AuthConsumer} from '../../providers/authProvider'

export const Register = () => (
    <AuthConsumer>
        {({ register }) => {
            register();
            return <span>loading</span>;
        }}
    </AuthConsumer>
);