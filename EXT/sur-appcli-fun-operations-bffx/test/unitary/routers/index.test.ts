import buildApp from '../../../src/adapter/http/app';

describe.skip('Fastify app routes', () => {
  it('GET /user/:id returns a user', async () => {
    const app = buildApp();

    const res = await app.inject({
      method: 'GET',
      url: '/user/7'
    });

    expect(res.statusCode).toBe(200);
    expect(JSON.parse(res.payload)).toEqual(
      expect.objectContaining({
        id: '7'
      })
    );
  });
});
