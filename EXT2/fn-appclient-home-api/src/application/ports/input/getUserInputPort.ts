export interface GetUserInputPort {
  execute(input: { id: string }): Promise<any>;
}
