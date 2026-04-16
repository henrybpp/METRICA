import handler from '../../../src/api/index';

describe.skip('Azure Functions handler', () => {
  it('routes /api/user/:id to Fastify and returns 200', async () => {
    const context: any = { log: { error: jest.fn() } };
    const req: any = {
      method: 'GET',
      url: 'http://localhost:7071/api/user/7',
      headers: {},
      body: undefined
    };

    await handler(context, req);

    expect(context.res.status).toBe(200);
    expect(context.res.body).toEqual(
      expect.objectContaining({
        id: '7'
      })
    );
  });
});
