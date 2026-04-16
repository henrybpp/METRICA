import type { Config } from 'jest';

const config: Config = {
  preset: 'ts-jest',
  testEnvironment: 'node',
  modulePathIgnorePatterns: ['<rootDir>/app/'],
  modulePaths: ['<rootDir>/src'],
  moduleNameMapper: {
    '^@/(.*)$': '<rootDir>/src/$1'
  },
  coverageDirectory: './coverage',
  collectCoverageFrom: [
    'src/**/*.ts'
  ],
  coverageReporters: [
    'json',
    'lcov',
    'cobertura',
    'text'
  ],
  setupFiles: ['./test/helpers/global.mocks.ts'],
  coveragePathIgnorePatterns: ['./src/index.ts']
};

export default config;
