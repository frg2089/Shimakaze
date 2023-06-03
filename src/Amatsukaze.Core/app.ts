import { JSONRPCServer, type SimpleJSONRPCMethod } from 'json-rpc-2.0'
import { stderr, stdin, stdout } from 'process'
import * as handlers from './handlers'

const server = new JSONRPCServer()
Object.keys(handlers).forEach(i => {
  server.addMethod(i, (handlers as Record<string, SimpleJSONRPCMethod<void>>)[i])
})

// eslint-disable-next-line @typescript-eslint/no-misused-promises
stdin.on('data', async raw => {
  const str = raw.toString()
  if (!str.trim()) { return }
  try {
    const data = JSON.parse(str)
    const response = await server.receive(data)
    stdout.write(JSON.stringify(response))
    stdout.write('\n')
  } catch (error) {
    stderr.write(JSON.stringify({ type: 'exception', error }))
    stderr.write('\n')
  }
})
