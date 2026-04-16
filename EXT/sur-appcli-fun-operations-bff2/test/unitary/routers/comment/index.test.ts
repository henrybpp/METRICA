import buildApp from '../../../../src/adapter/http/app';

describe.skip('User route', () => {
  it('GET /user/:id returns expected shape', async () => {
    const app = buildApp();

    const res = await app.inject({
      method: 'GET',
      url: '/user/123'
    });

    expect(res.statusCode).toBe(200);
    expect(JSON.parse(res.payload)).toEqual(
      expect.objectContaining({
        id: '123',
        name: expect.any(String),
        email: expect.any(String)
      })
    );
  });
});
