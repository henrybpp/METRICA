import 'reflect-metadata';
import { app } from '@azure/functions';

import './infrastructure/di/container';
import './functions/httpTriggerOperations';

app.setup({
    enableHttpStream: true,
});
