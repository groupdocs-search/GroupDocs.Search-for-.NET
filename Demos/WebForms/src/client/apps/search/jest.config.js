module.exports = {
  name: 'search',
  preset: '../../jest.config.js',
  coverageDirectory: '../../coverage/apps/search',
  snapshotSerializers: [
    'jest-preset-angular/AngularSnapshotSerializer.js',
    'jest-preset-angular/HTMLCommentSerializer.js'
  ]
};
