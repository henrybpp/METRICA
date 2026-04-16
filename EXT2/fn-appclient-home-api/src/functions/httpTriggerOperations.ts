import { app, HttpRequest, HttpResponseInit, InvocationContext } from "@azure/functions";
import { container } from '../infrastructure/di/container';
import { GetUserUseCase } from '../application/usecases/getUserUseCase';

export async function httpTriggerOperations(request: HttpRequest, context: InvocationContext): Promise<HttpResponseInit> {
    context.log(`Http function processed request for url "${request.url}"`);

    const name = request.query.get('name') || await request.text() || 'world';

    return { body: `Hello, ${name}!` };
};

app.http('httpTriggerOperations', {
    methods: ['GET', 'POST'],
    authLevel: 'anonymous',
    handler: httpTriggerOperations
});

export async function httpTriggerGetUser(request: HttpRequest, context: InvocationContext): Promise<HttpResponseInit> {
    context.log(`GetUser requested for url "${request.url}"`);

    const id = request.params?.id || request.query.get('id');
    if (!id) {
        return { status: 400, jsonBody: { error: 'Missing user id. Provide route param {id} or query param ?id=' } };
    }

    // Always resolve through DI
    const useCase = container.resolve(GetUserUseCase);
    const user = await useCase.execute({ id });

    if (!user) {
        return { status: 404, jsonBody: { error: 'User not found', id } };
    }

    return { status: 200, jsonBody: user };
}

app.http('httpTriggerGetUser', {
    methods: ['GET'],
    authLevel: 'anonymous',
    route: 'users/{id}',
    handler: httpTriggerGetUser
});
